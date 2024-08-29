import { DatabaseItem } from "./DatabaseItem.js"


export class VaultKeep extends DatabaseItem {
    constructor(data){
        super(data)
        this.keepId = data.keepId
        this.vaultId = data.vaultId
        this.creatorId = data.creatorId
    }
}