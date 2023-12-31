﻿import {SerializeService} from "../services/SerializeService.js";
import {LogModel} from "../models/LogModel.js";
import {RequestService} from "../services/RequestService.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class LogRepository {
    static async list() {
        const rawList = await RequestService.Get("/api/v1/logreader/list");

        let list = [];

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new LogModel());
            list.push(model)
        })

        return list;
    }

    static async delete(id) {
        return await RequestService.Delete('/api/v1/logreader/delete', id);
    }
    
    static async get(id) {
        const row = await RequestService.Get('/api/v1/logreader/read?id='+id);
        return SerializeService.serialize(row, new LogModel());
    }
    static async export(id)
    {
        return  await fetch('/api/v1/logreader/export',{
            method: 'POST',
            headers:{
                'Authorization': JwtResponseModel.getJwtResponse().accessToken,
                'Content-Type': 'application/vnd.ms-excel'
            },
            body: {
                id
            }
        })
    }
    //todo: экспорт
}