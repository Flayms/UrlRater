import { Component } from "@angular/core";
import { DataService } from "../Services/data.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent {

  public IsLiked = false;
  public IsDisliked = false;
  public Likes = 0;
  public Dislikes = 0;
  public Views = 1;
  public PageTitle = "";

  private _isManualChange = true;
  private readonly _urlSubscription: Subscription;

  constructor(private readonly _dataService: DataService) {
    this._urlSubscription = this._dataService.CurrentPageTitle.subscribe(title => {
      this.PageTitle = title;
    });
  }

  public LikePressed() {
    this.IsLiked = !this.IsLiked;
    this.Likes += this.IsLiked ? 1 : -1;

    //remove existing dislike
    if (this._isManualChange && this.IsDisliked) {
      this._isManualChange = false;

      this.DislikePressed();

      this._isManualChange = true;
    }
  }

  public DislikePressed() {
    this.IsDisliked = !this.IsDisliked;
    this.Dislikes += this.IsDisliked ? 1 : -1;

    //remove existing like
    if (this._isManualChange && this.IsLiked) {
      this._isManualChange = false;

      this.LikePressed();

      this._isManualChange = true;
    }
  }

}
