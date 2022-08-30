import { BaseEntity } from "src/app/shared/models/base-entity.model";

export class Organizasyon extends BaseEntity {
  /**Kayıt tekil bilgisidir. */
  id: number;

  /**Üst pozisyon tekil bilgisidir. */
  parentId: number | null;

  /**Kadro sayısı. */
  numberOfStaff: number;

  /**Pozisyonu isim bilgisidir. */
  name: string;

  /**Organizasyon Kodu */
  code: string;

  isBirimMudur: boolean;

  /**Üst pozisyon bilgilerini döndürür. */
  parent: Organizasyon;

  /**Alt kırılımlar */
  childs: Organizasyon[];
}
