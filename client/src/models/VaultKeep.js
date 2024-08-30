import { DatabaseItem } from "./DatabaseItem.js"
import { Keep } from "./Keep.js"


export class VaultKeep extends Keep {
    constructor(data){
        super(data)
        this.vaultKeepId = data.vaultKeepId
        this.keepId = data.keepId
        this.vaultId = data.vaultId
        this.creatorId = data.creatorId
    }
}