import { $authhost, $host } from "./index.js";

export const registration = async (email, password, name) => {
    const { data } = await $host.post('api/auth/regist', {email, password, name})
    return data;
}

export const login = async (email, password) => {
    const { data } = await $host.post('api/auth/login', {email, password})
    return data;
}

export const check = async () => {
    const {data} = await $authhost.get('api/auth/check')
}