import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table'
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import User from '../../Models/User'
import { UsersLocalService } from '../../Services/userslocal.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent implements OnInit
{

  users: User[]= [];
  title: string= "Home"

  displayedColumns: string[] = ["id","name"];

  constructor(private http: HttpClient) 
  {}


  ngOnInit(): void {
    this.getUsers();
  }

  getUsers()
  {
    this.http.get<User[]>('http://localhost:5066/User').subscribe({
      next: response => this.users = response,
      error: error => console.log(error)
      
    })

  }


}
