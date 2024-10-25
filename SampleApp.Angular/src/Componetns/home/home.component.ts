import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table'
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import User from '../../Models/User';
import Role from '../../Models/Role';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent implements OnInit
{
  
  
  //roles: Role[] = [];
  users: User[] = [];
  title: string= "Home"


  displayedColumnsUser: string[] = ["id","login"];

  //displayedColumnsRole: string[] = ["id","name"];



  constructor(private http: HttpClient) 
  {}


  ngOnInit(): void {
    this.getUsers();
    //this.getRoles();
  }

  getUsers()
  {
    this.http.get<User[]>('http://localhost:5066/User').subscribe({
      next: response => this.users = response,
      error: error => console.log(error)
      
    }) 
  }
/*
  getRoles()
  {
      this.http.get<Role[]>('http://localhost:5066/Role').subscribe({
        next: response => this.roles = response,
        error: error => console.log(error)
        
      }) 
  }
*/
  


}
