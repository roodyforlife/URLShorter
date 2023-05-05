import axios from 'axios'
import { SERVER_API } from '../utils/consts'

const $host = axios.create({
    baseURL: SERVER_API
})

const $authhost = axios.create({
    baseURL: SERVER_API
})

const authInterceptor = config => {
    config.headers.authorization = `Bearer ${localStorage.getItem('token')}`
    return config;
}

$authhost.interceptors.request.use(authInterceptor);

export {
    $host,
    $authhost
}