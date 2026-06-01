import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SponsorsService } from '../../services/sponsorsService';
import { SponsorModel } from '../../models/sponsors';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sponsors',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sponsors.component.html',
  styleUrls: ['./sponsors.component.css']
})
export class SponsorsComponent implements OnInit {

  sponsors: SponsorModel[] = [];

  constructor(
    private router: Router,
    private sponsorsService: SponsorsService
  ) {}

  get isHidden(): boolean {
    return this.router.url === '/';
  }

  ngOnInit(): void {
    this.loadSponsors();
  }

  loadSponsors(): void {
    this.sponsorsService.getSponsors().subscribe({
      next: (data) => {
        this.sponsors = data;
        console.log('Sponsors loaded:', data);
      },
      error: (err) => {
        console.error('Failed to load sponsors', err);
      }
    });
  }
}