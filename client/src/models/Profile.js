import { DatabaseItem } from "./DatabaseItem";


export class Profile extends DatabaseItem {
    constructor(data) {
        super(data);
        this.name = data.name;
        this.picture = data.picture;
        this.coverImg = data.coverImg;
    }
}
