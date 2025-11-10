import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sponsors',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './sponsors.html',
  styleUrls: ['./sponsors.css']
})
export class SponsorsComponent {
  sponsors = [
    { name: 'Red Bull' },
    { name: 'Intel' },
    { name: 'Riot Games' },
    { name: 'Logitech' },
    { name: 'HyperX' },
    { name: 'SteelSeries' },
    { name: 'Corsair' }
  ];
}
