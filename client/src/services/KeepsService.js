import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"


class KeepsService {
  async createKeep(keepData) {
      const response = await api.post('api/keeps', keepData)
      logger.log("Created a keep", response.data)
      const newKeep = new Keep(response.data)
      AppState.keeps.push(newKeep)
  }
  async getKeepById(keepId) {
      const response = await api.get(`api/keeps/${keepId}`)
      logger.log("Got the keep via its id", response.data)
  }
  setActiveKeep(keepProp) {
      AppState.activeKeep = keepProp
  }
  
  async getKeeps() {
    const response = await api.get('api/keeps')
    logger.log("Got the keeps", response.data)
    AppState.keeps = response.data.map(keepPOJO => new Keep(keepPOJO))
  }
}

export const keepsService = new KeepsService()