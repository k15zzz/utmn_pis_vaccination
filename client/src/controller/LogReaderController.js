import {reactive} from 'vue';
import {LogRepository} from "../repositorys/LogRepository.js";
import {HelperController} from "./HelperController.js";


export class LogReaderController extends HelperController {
    backLink = '/logs-registry'
    value = reactive({
        id: null,
        surname: null,
        name: null,
        patronymic: null,
        phone: null,
        email: null,
        organization: null,
        position: null,
        work_phone: null,
        work_email: null,
        login: null,
        date_time: null,
        object_instance_id: null,
        object_description_after_action: null
    });

    constructor(type, id = 0) {
        super(type, id);
    }

    async read(id) {
        const model = await LogRepository.get(id);
        this.value.id = model.id;
        this.value.surname = model.surname;
        this.value.name = model.name;
        this.value.patronymic = model.patronymic;
        this.value.phone = model.phone;
        this.value.email = model.email;
        this.value.organization = model.organization;
        this.value.position = model.position;
        this.value.work_phone = model.workPhone;
        this.value.work_email = model.workEmail;
        this.value.login = model.login;
        this.value.date_time = model.logDate;
        this.value.object_instance_id = model.objId;
        this.value.object_description_after_action = model.objDescr;
    }

    async delete(id) {
        let resp = await LogRepository.delete(id);
        if (resp) {
            this.router.push(this.backLink);
        }
    }

    async export(id)
        {
            this.read(id)
            const apiEndpoint = '/api/v1/logreader/export?id='+id;

            const a = document.createElement('a');
            a.href = apiEndpoint;
            a.download = 'log.csv'; // Укажите имя файла
            a.style.display = 'none'; // Скрываем элемент

            // Добавляем ссылку на документ и эмулируем клик
            document.body.appendChild(a);
            a.click();

            // Удаляем ссылку из документа
            document.body.removeChild(a);
        }
}
//todo экспорт