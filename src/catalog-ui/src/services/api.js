import axios from "axios";

class Api {
  constructor() {
    this.apiClient = axios.create({
      baseURL: process.env.REACT_APP_API_URL,
      headers: {
        'Content-type': 'application/json'
      }
    });
  }
}

export default Api;