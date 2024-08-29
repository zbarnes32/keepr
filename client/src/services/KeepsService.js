import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"


class KeepsService {
  async getProfileKeeps(profileId) {
      AppState.profileKeeps = []

      const response = await api.get(`api/profiles/${profileId}/keeps`)
      logger.log("Got the keeps for the profile.", response.data)
      const profileKeeps = response.data.map(profileKeepPOJO => new Keep(profileKeepPOJO))
      AppState.profileKeeps = profileKeeps
  }
  async destroyKeep(keepId) {
    const response = await api.delete(`api/keeps/${keepId}`)
    logger.log('Deleting the keep', response.data)
    AppState.activeKeep = null
    const keepIndex = AppState.keeps.findIndex(keep => keep.id == keepId)
    const myKeepIndex = AppState.myKeeps.findIndex(myKeep => myKeep.id == keepId)
    if (keepIndex == -1) throw new Error("Unable to find the keepIndex.")
    AppState.keeps.splice(keepIndex, 1)
    AppState.myKeeps.splice(myKeepIndex, 1)
  }

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

    // FIXME GO GET THE KEEP BY ITS ID

      AppState.activeKeep = keepProp
  }
  
  async getKeeps() {
    const response = await api.get('api/keeps')
    logger.log("Got the keeps", response.data)
    AppState.keeps = response.data.map(keepPOJO => new Keep(keepPOJO))
  }
}

export const keepsService = new KeepsService()