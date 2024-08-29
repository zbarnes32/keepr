import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"
import { Profile } from "@/models/Profile.js"


class ProfileService {
  async getProfileById(profileId) {
      AppState.profile = null

      const response = await api.get(`api/profiles/${profileId}`)
      logger.log("Got the profile", response.data)
      const profile = new Profile(response.data)
      AppState.profile = profile
  }
  
  async getMyKeeps() {
    const profileId = AppState.account.id
    const response = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log("Getting my keeps", response.data)
    const myKeeps = response.data.map(keepData => new Keep(keepData))
    AppState.myKeeps = myKeeps
  }

}

export const profileService = new ProfileService()