import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManufacturerService } from '../services/manufacturer.service';

@Component({
  selector: 'app-manufacturer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './manufacturer.component.html',
  styleUrls: ['./manufacturer.component.css'],
})
export class ManufacturerComponent implements OnInit {
  manufacturers: Array<{ id?: number; name: string }> = [];
  loading = false;
  error = '';

  constructor(private manufacturerService: ManufacturerService) {}

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.loading = true;
    this.error = '';
    this.manufacturerService.getManufacturers().subscribe({
      next: (result) => {
        this.manufacturers = result.data || [];
        this.loading = false;
    },
      error: (err) => {
        console.warn('Failed to load manufacturers', err);
        this.loading = false;
        this.error = 'Could not load manufacturers from API; showing sample data.';
        this.manufacturers = [
          { id: 1, name: 'Acme Motors' },
          { id: 2, name: 'Global Automotive' },
          { id: 3, name: 'Sunrise Vehicles' },
        ];
      },
    });
  }
}
