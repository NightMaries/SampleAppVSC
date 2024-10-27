import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatInputModule, MatLabel } from '@angular/material/input';
import { Router } from '@angular/router';
import { errorContext } from 'rxjs/internal/util/errorContext';
import { AuthService } from '../../Services/auth.service';


@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [FormsModule, CommonModule,MatInputModule,  MatFormField, MatLabel, MatIcon, MatButton],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent {

  
  model: any = {}
  router:Router = new Router()
  

  constructor(public authService: AuthService){}

  login(){
    this.authService.login(this.model).subscribe({next: r => {console.log(r); this.router.navigate(["home"])}, error: e => console.log(e.error)})
  }

  sign()
  {
    this.authService.register(this.model).subscribe({next: r => {console.log(r)}, error: e => console.log(e.error)})
  }

  logout()
  {
    this.authService.logout();
  }
}

