export default class Resources {
  public static AvailablePages = {
    homePage: "/home",
    userProfilePage: "/profile",
    aboutUsPage: "/aboutUs",
    adminDashboardPage:"/dashboardAdmin",
  };

  public static PageHeader = {
    homePage: "Strona główna",
    profilePage: "Profil",
    registerPage: "Rejestracja",
    loginPage: "Logowanie",
  };

  public static ModalHeader = {
    AddCountry: "Dodaj kraj",
    AddCity:"Dodaj miasto",
    AddOffer:"Dodaj ofertę",
    AddMeal:"Dodaj typ posiłku",
    AddHotel:"Dodaj hotel",
  };

  public static PageNames = {
    homePage: "Strona główna",
    profilePage: "Profil",
    adminDashboardPage: "Dashboard administratora",
    aboutUsPage: "O nas",
  };

  public static InputPlaceholder = {
    email: "Email",
    password: "Hasło",
    firstName: "Imię",
    lastName: "Nazwisko",
    phoneNumber: "Numer telefonu",
    countryName: "Kraj",
    cityName: "Miasto",
    meal: "Posiłek",
    name: "Nazwa",
    isAirport: "Lotnisko",
    description: "Opis",
    dateFrom:"Od",
    dateTo: "Do",
    numberOfPeople: "Liczba gości",
    price: "Cena",
    photoPaths: "ścieżki",
    mealsId: "Typ posiłku",
    hotelId: "Hotel",
    star:"Gwiazdki",
  };

  public static Validation = {
    passwordConfirmation: "Hasło nie zgadza się",
    phoneNumber: "Numer telefonu nie jest prawidłowy",
    passwordPolicy: "Hasło musi zawierać małą i wielką literę oraz cyfrę",
  };

  public static Notifications = {
    loginForm_successTitle: "Zalogowano pomyślnie",
    loginForm_successMessage: "",
    loginForm_failureTitle: "Błąd logowania",
    loginForm_failureMessage: "Błędne dane logowania",

    registerForm_successTitle: "Zarejestrowano pomyślnie",
    registerForm_successMessage: "",
    registerForm_failureTitle: "Błąd rejestracji",
    registerForm_failureMessage: "Błędne dane rejestracji",

    logOut_successTitle: "Wylogowano pomyślnie",
    logOut_successMessage: "",
    logOut_failureTitle: "Błąd podczas wylogowywania",
    logOut_failureMessage: "Ups!",

    odata_getListErrorTitle: "Wystąpił błąd przy pobieraniu danych.",
    odata_getSingleErrorTitle: "Wystąpił błąd przy pobieraniu obiektu.",

    registrationShopForm_SuccessTitle: "Pomyślnie zarejestrowano sklep",
    registrationShopForm_SuccessMessage: "",
    registrationShopForm_failureTitle: "Błąd rejestracji sklepu",
    registrationShopForm_failureMessage: "Wystąpił błąd podczas rejestracji sklepu",

    successTitle: "Akcja zakończona sukcesem.",
    successMessage: "Yay!",

    failureTitle: "Ups!",
    failureMessage: "Ta tablica tutaj nie stała!",
  };
  public static BusinessNames = {
    offers: "Oferty",
    hotels: "Hotele",
    cities: "Miasta",
    countries: "Kraje",
    meals: "Posiłki",
  };
  public static Buttons = {
    layout_signIn: "Zaloguj",
    layout_register: "Zarejestruj",
    layout_signOut: "Wyloguj",
    addCity:"Dodaj miasto",
    addMeal:"Dodaj typ posiłku",
    addCountry: "Dodaj kraj",
    addHotel: "Dodaj hotel",
    remove: "Usuń",
    addOffer:"Dodaj ofertę"
  };

  static persistentKeys = {
    User: "User",
  };

  public static ColumnTitles = {
    city: "Miasto",
    country: "Kraj",
    isAirport: "Lotnisko",
    action: "Akcja",
    meal: "Posiłek",
    offer: "Oferta",
    stars:"Gwiazdki",
  };
}
