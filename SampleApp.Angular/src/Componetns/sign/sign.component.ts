import { Component } from '@angular/core';
import { AuthService } from '../../Services/auth.service';
import { CommonModule } from '@angular/common';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInput, MatInputModule } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { routes } from '../../app/app.routes';
import { Router, Routes } from '@angular/router';

@Component({
  selector: 'app-sign',
  standalone: true,
  imports: [CommonModule, MatFormField, FormsModule, MatLabel, MatInputModule, MatButton, MatIcon],
  templateUrl: './sign.component.html',
  styleUrl: './sign.component.css'
})

export class SignComponent {

  constructor(public authService: AuthService){}


  model:any = {}
  router: Router = new Router();

  sign()
  {
    this.authService.register(this.model).subscribe({next: r => {console.log(r); this.router.navigate(["auth"])}, error: e => console.log(e)})
  }
}
