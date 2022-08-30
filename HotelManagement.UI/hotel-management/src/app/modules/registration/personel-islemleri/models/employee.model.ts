import { BaseEntity } from "src/app/shared/models/base-entity.model";
import { User } from "../../kullanici-islemleri/models/user.model";
import { Organizasyon } from "../../organizasyon-islemleri/models/organizasyon.model";

export class Employee extends BaseEntity {
    /**Tablo tekil bilgisdir. */
    id: number;

    /**Personelin sistem üzerinde hesabu */
    userId: number | null;

    /**Personel organizasyon bilgisi */
    organizasyonId: number | null;

    /**Personel Sicil numarası/kodu */
    employeeCode: string;

    /**Personel adı */
    name: string;

    /**Personel soyadı */
    surname: string;

    /**Personel Telefon numarası */
    phoneNumber: string;

    /**Personel email bilgisi */
    email: string;

    /**Personelin işe giriş tarihi */
    jobStartDate: Date | string;

    myProperty: number;
    user: User;
    organizasyon: Organizasyon;
}