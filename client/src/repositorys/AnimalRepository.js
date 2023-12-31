import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";
import {RequestService} from "../services/RequestService.js";

export class AnimalRepository {
    static async list() {
        const rawList = await RequestService.Get("/api/v1/animal/list");
        let list = [];
        
        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new AnimalModel());
            list.push(model)
        })
        
        return list;
    }
    
    static async delete(id) {
        return await RequestService.Delete('/api/v1/animal/delete', id);
    }

    static async update(
        id,
        regNum,
        sex,
        yearBirth,
        electronicChipNumber,
        name,
        specialMarks,
        fkAnimalCategory,
        fkTown)
    {
        let model = {
            id,
            regNum,
            sex,
            yearBirth,
            electronicChipNumber,
            name,
            specialMarks,
            fkAnimalCategory,
            fkTown
        };

        return await RequestService.Put('/api/v1/animal/update', model);
    }

    static async create( 
        regNum, 
        sex, 
        yearBirth,
        electronicChipNumber,
        name,
        specialMarks,
        fkAnimalCategory,
        fkTown) 
    {
        let model = {
            regNum,
            sex,
            yearBirth,
            electronicChipNumber,
            name,
            specialMarks,
            fkAnimalCategory,
            fkTown
        };
        
        return await RequestService.Post('/api/v1/animal/create', model);
    }
    
    static async get(id) {
        const row = await RequestService.Get('/api/v1/animal/read?id='+id);
        return SerializeService.serialize(row, new AnimalModel());
    }
    
    static async categoryList() 
    {
        return await RequestService.Get('/api/v1/animalCategory/list');
    }

    static async townList()
    {
        return await RequestService.Get('/api/v1/town/list');
    }
}