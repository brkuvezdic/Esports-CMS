import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-hero',
  imports: [],
  templateUrl: './hero.html',
  styleUrl: './hero.css',
})
export class Hero {
    constructor(public router: Router) {}

  get isHidden(): boolean {
    return this.router.url === '/';
  }
}
