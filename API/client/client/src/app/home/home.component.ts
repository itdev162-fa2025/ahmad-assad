import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  posts: any[] = []; // Array to store the posts

  constructor(private http: HttpClient) {}

  ngOnInit() {
    // Fetch posts from your API endpoint
    this.http.get<any[]>('your-api-endpoint/posts').subscribe(data => {
      this.posts = data;
    });
  }
}