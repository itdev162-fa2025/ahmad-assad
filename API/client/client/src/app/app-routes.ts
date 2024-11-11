import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { ViewPostComponent } from './view-post/view-post.component';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },  // Home page route
  { path: 'create-post', component: CreatePostComponent },
  { path: 'view-post/:id', component: ViewPostComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' } // Wildcard route for invalid paths
];