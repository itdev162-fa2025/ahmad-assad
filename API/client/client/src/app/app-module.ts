import { NgModule } from '@angular/core';  // Make sure this is present
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app-routes'; // Import your routes

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { ViewPostComponent } from './view-post/view-post.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreatePostComponent,
    ViewPostComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes), // Import the routes
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }