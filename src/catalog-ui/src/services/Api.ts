import axios, {AxiosInstance } from "axios";

class Api {
    api: AxiosInstance;

    constructor() { 
        this.api = axios.create({
            baseURL: process.env.REACT_APP_API_URL,
            headers: {
                'Content-type': 'application/json'
            }
        })
    }
}

export default Api;