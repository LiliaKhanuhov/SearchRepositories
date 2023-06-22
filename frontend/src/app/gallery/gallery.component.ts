import { Component, EventEmitter, Input, OnDestroy, Output } from '@angular/core';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.less']
})
export class GalleryComponent implements OnDestroy {
  @Input() repositories: any[] = [];
  @Output() bookmarkClicked: EventEmitter<any> = new EventEmitter<any>();

  clicked = false;
  onBookmarkClick(repository: any) {
    this.bookmarkClicked.emit(repository);
    if (!this.clicked) {
      var button = document.getElementById("btn-bm");
      button?.classList.add("clicked");
      this.clicked = !this.clicked;
    }
  }
   
  ngOnDestroy(): void {
    var button = document.getElementById("btn-bm");
    button?.classList.remove("clicked");

  }
}
