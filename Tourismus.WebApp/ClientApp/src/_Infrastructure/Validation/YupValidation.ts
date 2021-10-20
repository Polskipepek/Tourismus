import * as Yup from 'yup';

Yup.setLocale({
  mixed: {
    default: "Wartość jest nieprawidłowa",
    required: "Pole jest wymagane",
    notType: "Wartość jest nieprawidłowa",
    defined: "Pole jest wymagane",
  },
  array: {
    min: "Minimalna ilość elementów: ${min}",
    max: "Maksymalna ilość elementów: ${max}",
  },
  number: {
    min: "Minimalna wartość musi być większa lub równa ${min}",
    max: "Maksymalna wartość musi być mniejsza lub równa ${max}",
    lessThan: "Wartość musi być mniejsza niż ${less}",
    moreThan: "Wartość musi być większa niż ${more}",
    integer: "Wartość musi być liczbą całkowitą",
  },
  string: {
    email: "Niepoprawny format emaila",
    min: "Wymagana minimalna liczba znaków: ${min}",
    max: "Wymagana maksymalna liczba znaków: ${max}",
    matches: 'Wartość musi być zgodna z formatem "${regex}"',
  },
});

export default Yup;
