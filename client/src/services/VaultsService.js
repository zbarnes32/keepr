import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"


class VaultsService {
    async getVaults() {
        const response = await api.get('api/vaults')
        logger.log("Got the vaults", response.data)
        AppState.vaults = response.data.map(vaultPOJO => new Vault(vaultPOJO))
    }
    async createVault(vaultData) {
        const response = await api.post('api/vaults', vaultData)
        logger.log("Created a vault!", response.data)
    }

}

export const vaultsService = new VaultsService()