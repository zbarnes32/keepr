import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { VaultKeep } from "@/models/VaultKeep.js"


class VaultKeepsService {
  async removeKeepFromVault(vaultKeepId) {
    const response = await api.delete(`api/vaultKeeps/${vaultKeepId}`)
    logger.log("Removed the keep from this vault", response.data)
    const vaultKeepIndex = AppState.vaultKeepKeeps.findIndex(vaultKeep => vaultKeep.id == vaultKeepId)
    AppState.vaultKeepKeeps.splice(vaultKeepIndex, 1)
  }
  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultKeeps', vaultKeepData)
    logger.log("Created a vaultKeep", response.data)
    const vaultKeep = new VaultKeep(response.data)

    AppState.vaultKeeps.push(vaultKeep)
  }

}


export const vaultKeepsService = new VaultKeepsService()