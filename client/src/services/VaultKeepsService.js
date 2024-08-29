import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { VaultKeep } from "@/models/VaultKeep.js"


class VaultKeepsService {
  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultKeeps', vaultKeepData)
    logger.log("Created a vaultKeep", response.data)
    const vaultKeep = new VaultKeep(response.data)

    AppState.vaultKeeps.push(vaultKeep)
  }

}


export const vaultKeepsService = new VaultKeepsService()