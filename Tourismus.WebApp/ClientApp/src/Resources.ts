export default class Resources {
  public static AvailablePages = {
    homePage: "/home",
    userProfilePage: "/profile",
    aboutUsPage: "/aboutUs",
    registerShop: "/registerShop/:token",
  };

  public static PageHeader = {
    homePage: "Strona główna",
    profilePage: "Profil",
    registerPage: "Rejestracja",
    loginPage: "Logowanie",
  };

  public static PageNames = {
    homePage: "Strona główna",
    profilePage: "Profil",
    aboutUsPage: "O nas",
  };

  public static InputPlaceholder = {
    email: "Email",
    password: "Hasło",
    firstName: "Imię",
    lastName: "Nazwisko",
    phoneNumber: "Numer telefonu",
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
  };

  public static Buttons = {
    layout_signIn: "Zaloguj",
    layout_register: "Zarejestruj",
    layout_signOut: "Wyloguj",
  };

  static persistentKeys = {
    User: "User",
  };
}
