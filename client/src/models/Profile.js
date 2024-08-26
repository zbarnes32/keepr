import { DatabaseItem } from "./DatabaseItem";


export class Profile extends DatabaseItem {
    constructor(data) {
        super(data);
        this.name = data.name;
        this.picture = data.picture;
        // TODO add additional properties if needed
        this.coverImg = data.coverImg;
    }
}
