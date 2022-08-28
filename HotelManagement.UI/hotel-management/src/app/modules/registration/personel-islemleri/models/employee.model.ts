import { BaseEntity } from 'src/app/shared/models/base-entity.model';
import { User } from '../../kullanici-islemleri/models/user.model';

export class Employee extends BaseEntity {
  /**Tablo tekil bilgisdir. */
  id: number;

  /**Personelin sistem üzerinde hesabu */
  userId: number | null;

  /**Personel Tipi */
  employeeType: EmployeeType;

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
  user: User;
}

export enum EmployeeType {
  GenelMudur,
  GenelMudurYardimci,
  OnBuro,
  Muhasebe,
  MuhasebeMudur,
  Temizlik,
  Mutfak,
  Teknik,
  Guvenlik,
  Aktivite,
  InsanKaynaklari,
  InsanKaynaklariMudur,
  SatinAlma,
  SatinAlmaMudur,
  Stajyer,
}

export const EmployeeTypeDataSource = [
  { id: EmployeeType[EmployeeType.GenelMudur], name: 'Genel Müdür' },
  { id: EmployeeType[EmployeeType.GenelMudurYardimci], name: 'Genel Müdür Yardımcısı' },
  { id: EmployeeType[EmployeeType.OnBuro], name: 'Ön Büro Personeli' },
  { id: EmployeeType[EmployeeType.Muhasebe], name: 'Muhasebe' },
  { id: EmployeeType[EmployeeType.MuhasebeMudur], name: 'Muhasebe Birim Müdürü' },
  { id: EmployeeType[EmployeeType.Temizlik], name: 'Temizlik Personeli' },
  { id: EmployeeType[EmployeeType.Mutfak], name: 'Mutfak Personeli' },
  { id: EmployeeType[EmployeeType.Teknik], name: 'Teknik Personel' },
  { id: EmployeeType[EmployeeType.Guvenlik], name: 'Güvenlik Personeli' },
  { id: EmployeeType[EmployeeType.Aktivite], name: 'Aktivite Personeli' },
  { id: EmployeeType[EmployeeType.InsanKaynaklari], name: 'İnsan Kaynakları' },
  { id: EmployeeType[EmployeeType.InsanKaynaklariMudur], name: 'İnsan Kaynakları Birim Müdürü' },
  { id: EmployeeType[EmployeeType.SatinAlma], name: 'Satın Alma' },
  { id: EmployeeType[EmployeeType.SatinAlmaMudur], name: 'Satın Alma Birim Müdürü' },
  { id: EmployeeType[EmployeeType.Stajyer], name: 'Stajyer' },
];
