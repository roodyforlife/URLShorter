import { $authhost, $host } from "./index.js";
import jwt_decode from 'jwt-decode';
import axios from "axios";

export const create = async (url, userId) => {
    const { data } = await $authhost.post('api/url/create', {link: url, userId})
    return data;
}

export const getUrls = async () => {
    const { data } = await $host.get('api/url/get')
    return data;
}

export const getOne = async (link) => {
    const { data } = await $host.get('api/url/' + link)
    return data;
}

export const deleteLink = async (id) => {
    const { data } = await $host.delete(`api/url/${id}`)
    return data;
}

export const visit = async (link) => {
    await axios.get("https://api.ipify.org/?format=json").then(({data}) => {
        $host.post('api/url/visit', {link, IP: data.ip})
    });
}