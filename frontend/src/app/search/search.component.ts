import { Component, NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.less']
})

export class SearchComponent {
  searchKeyword: string = '';
  searchResults: any[] = [];

  constructor(private http: HttpClient) { }

  performSearch() {
    if (!this.searchKeyword) {
      return;
    }

    const apiUrl = `https://localhost:7110/api/Repositories/PerformSearch?q=${encodeURIComponent(this.searchKeyword)}`;
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        this.searchResults = response.items;
      },
      (error) => {
        console.error('Error occurred during search:', error);
      }
    );
  }

  handleBookmark(repository: any) {
    //temp
    if (repository.mirror_url == null) {
      repository.mirror_url = "mirror_url";
    }
    
    this.http.post('https://localhost:7110/api/Repositories/SetData', repository).subscribe(
      (response) => {
        console.log('Repository bookmarked:', repository);
      },
      (error) => {
        console.error('Bookmarking failed:', error);
      }
    );
  }
}
