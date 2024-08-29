import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"


class VaultsService {
    async getMyVaults() {
      const response = await api.get('account/vaults')
      logger.log("Getting my vaults", response.data)
      const myVaults = response.data.map(vaultData => new Vault(vaultData))
      AppState.myVaults = myVaults
    }
    async destroyVault(vaultId) {
        const response = await api.delete(`api/vaults/${vaultId}`)
        logger.log("Deleted vault", response.data)
        // TODO remove the vault from my vaults in the appstate
        // AppState.activeVault = null
    }
    setActiveVault(vaultProp) {
        AppState.activeVault = vaultProp
    }
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