import {makeAutoObservable} from 'mobx';

export default class UrlStore {
    constructor() {
        this._urls = [];
        makeAutoObservable(this);
    }

    setUrls(urls) {
        this._urls = urls;
    }

    get urls() {
        return this._urls;
    }
}