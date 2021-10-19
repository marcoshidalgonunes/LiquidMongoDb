import axios from "axios";

class Api {
  constructor() {
    this.apiClient = axios.create({
      baseURL: 'https://localhost:44398/api/',
      headers: {
        'Content-type': 'application/json'
      }
    });
  }
}

export default Api;