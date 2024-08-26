import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"


class KeepsService {
  async getKeeps() {
    const response = await api.get('api/keeps')
    logger.log("Got the keeps", response.data)
    AppState.keeps = response.data.map(keepPOJO => new Keep(keepPOJO))
  }
}

export const keepsService = new KeepsService()