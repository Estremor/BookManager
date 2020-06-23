export class Category {
    identificador: number;
    nombre: string;
    descripcion: string;
}


export class Author {

    identificador: number;
    nombre: string;
    apellido: string;
    fechaNacimiento: Date;
}

export class Book {
    identificador: number;
    nombre: string;
    author: number;
    category: number;
    isbn: string;
}

export class BookModel{
    name:string;
    categori:string;
    autor:string;
}

export class BookResult{
    nombre: string;
    isbn: string;
    autor: string;
    categoria: string;
}


export interface IRequestResult<T> {
    isSuccesfull: boolean;
    result: T;
    Messges: string;
}