import { Component } from '@angular/core';

import { Router } from '@angular/router';

@Component({
  selector: 'app-sponsors',
  standalone: true,
  imports: [],
  templateUrl: './sponsors.html',
  styleUrls: ['./sponsors.css']
})
export class SponsorsComponent {

    constructor(private router: Router) {}

  get isHidden(): boolean {
    return this.router.url === '/';
  }
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
