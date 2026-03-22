using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<PagedResponse<ManufacturerDTO>> GetAllWithPagination(QueryFilter filter, CancellationToken cancellationToken = default)
        {
            var pageNumber = Math.Max(1, filter.PageNumber);
            var pageSize = Math.Clamp(filter.PageSize, 1, 50);

            var query = _context.Manufacturers.AsNoTracking().AsQueryable();

            // 1. Apply search filter (reduces the dataset)
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(m =>
                    EF.Functions.Like(m.Name, $"%{filter.Search}%"));
            }

            // 2. Count total records AFTER filtering, BEFORE pagination
            var totalRecords = await query.CountAsync(cancellationToken);

            // 3. Apply sorting (default to Name if not specified)
            if (!string.IsNullOrWhiteSpace(filter.SortBy)
                && filter.SortBy.Contains("name desc", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(x => x.Name);
            }
            else
            {
                query = query.OrderBy(x => x.Name);
            }

            // 4. Apply pagination and project to DTOs
            var movies = await query
                .ApplyPagination(pageNumber, pageSize)
                .Select(m => new ManufacturerDTO(m.Id, m.Name))
                .ToListAsync(cancellationToken);

            return new PagedResponse<ManufacturerDTO>
            {
                Data = movies,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };
        }

    }
}
