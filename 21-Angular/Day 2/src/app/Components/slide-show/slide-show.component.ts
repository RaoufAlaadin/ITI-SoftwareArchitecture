import { Component } from '@angular/core';

@Component({
  selector: 'app-slide-show',
  templateUrl: './slide-show.component.html',
  styleUrls: ['./slide-show.component.css']
})
export class SlideShowComponent {

  images: string[] = [
    'assets/Images/1.jpg',
    'assets/Images/2.jpg',
    'assets/Images/3.jpg',
    'assets/Images/4.jpg',
    'assets/Images/5.jpg',
    'assets/Images/6.jpg'

  ];

  currentIndex = 0;

  // This is needed to clear the interval.
  slideshowInterval: any;

  previousImage() {

    if(this.currentIndex !== 0)
    this.currentIndex = this.currentIndex - 1 ;
    // this.currentIndex = this.currentIndex === 1 ? this.images.length - 1 : this.currentIndex - 1;
  }

  nextImage() {
    if(this.currentIndex !== (this.images.length - 1))
    this.currentIndex = this.currentIndex + 1 ;
    // this.currentIndex = this.currentIndex === this.images.length - 1 ? 0 : this.currentIndex + 1;
  }

  startSlideshow() {
    this.slideshowInterval = setInterval(() => {
      this.nextImage();
    if(this.currentIndex === (this.images.length - 1))
      this.currentIndex = 0;


    }, 1500);
  }

  stopSlideshow() {
    clearInterval(this.slideshowInterval);
  }

}
