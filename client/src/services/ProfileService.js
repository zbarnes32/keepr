import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"


class ProfileService {
  async getMyKeeps() {
    const profileId = AppState.account.id
    const response = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log("Getting my keeps", response.data)
    const myKeeps = response.data.map(keepData => new Keep(keepData))
    AppState.myKeeps = myKeeps
  }

}

export const profileService = new ProfileService()