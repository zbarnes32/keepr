import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"


class KeepsService {
  async getKeeps() {
    const response = await api.get('api/keeps')
    logger.log("Got the keeps", response.data)
  }
}

export const keepsService = new KeepsService()