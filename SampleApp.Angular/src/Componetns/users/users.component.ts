import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import User from '../../Models/User';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent {

  users: User[] = [];
  title: string= "Home"
  baseUrl: String= "http://localhost:5066/"

  displayedColumnsUser: string[] = ["id","login"];

  constructor(private http: HttpClient) 
  {}


  ngOnInit(): void {
    this.getUsers();
    
  }

  getUsers()
  {
    this.http.get<User[]>(this.baseUrl +"User").subscribe({
      next: response => this.users = response,
      error: error => console.log(error)
      
    }) 
  }
}
