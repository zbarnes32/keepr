import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"


class VaultsService {
    async getKeepsInVault(vaultId) {
      const response = await api.get(`api/vaults/${vaultId}/keeps`)
      logger.log("Getting the keeps inside of the vault", response.data)
      const vaultKeeps = response.data.map(vaultKeepPOJO => new Keep(vaultKeepPOJO))
      AppState.vaultKeepKeeps = vaultKeeps
    }
    async getVaultById(vaultId) {
      const response = await api.get(`api/vaults/${vaultId}`)
      logger.log("Got the vault id", response.data)
      const vault = new Vault(response.data)
      AppState.activeVault = vault
    }
    async getProfileVaults(profileId) {
        AppState.profileVaults = []

        const response = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('Got the vaults for the profile', response.data)
        const profileVaults = response.data.map(profileVaultPOJO => new Vault(profileVaultPOJO))
        AppState.profileVaults = profileVaults
    }
    async getMyVaults() {
      const response = await api.get('account/vaults')
      logger.log("Getting my vaults", response.data)
      const myVaults = response.data.map(vaultData => new Vault(vaultData))
      AppState.myVaults = myVaults
    }
    async destroyVault(vaultId) {
        const response = await api.delete(`api/vaults/${vaultId}`)
        logger.log("Deleted vault", response.data)
        // NOTE Deleting from the myVaults array, but not the vaults array.
        const vaultIndex = AppState.myVaults.findIndex(vault => vault.id == vaultId)
            if(vaultIndex == -1) throw new Error("Unable to find the vaultIndex")
            AppState.myVaults.splice(vaultIndex, 1)
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