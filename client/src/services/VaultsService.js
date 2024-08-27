import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"


class VaultsService {
    async createVault(vaultData) {
        const response = await api.post('api/vaults')
        logger.log("Created a vault!", response.data)
    }

}

export const vaultsService = new VaultsService()