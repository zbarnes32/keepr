import { DatabaseItem } from "./DatabaseItem.js";
import { Profile } from "./Profile.js";


export class Keep extends DatabaseItem {
    constructor(data){
        super(data)
        this.name = data.name;
        this.description = data.description;
        this.img = data.img;
        this.views = data.views;
        this.creatorId = data.creatorId;
        this.creator = new Profile(data.creator);
        this.kept = data.kept;
    }
}