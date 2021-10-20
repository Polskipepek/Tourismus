export default class Resources {
  public static AvailablePages = {
    homePage: "/home",
    userProfilePage: "/profile",
    aboutUsPage: "/aboutUs",
    registerShop: "/registerShop/:token",
  };

  public static PageHeader = {
    homePage: "Home Page",
    profilePage: "Profile Page",
    registerPage: "Rejestracja",
    loginPage: "Logowanie",
  };

  public static PageNames = {
    homePage: "Home",
    profilePage: "Profile",
    aboutUsPage: "About us",
  };

  public static InputPlaceholder = {
    email: "Email",
    password: "Password",
    nickname: "Nickname",
    phoneNumber: "Phone number",
  };

  public static Validation = {
    passwordConfirmation: "Hasło nie zgadza się",
    phoneNumber: "Numer telefonu nie jest prawidłowy",
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
    layout_signedIn: "Wyloguj",
  };

  public static RegistrationShopPage = {
    textOnValidToken: "Rejestracja sklepu:",
    textOnUnvalidToken: "Błedny token",
  };

  public static RegistrationShopForm = {
    labelName: "Nazwa",
    labelDescription: "Opis",
    labelNIPNumber: "Numer NIP",
    labelRegonNumber: "Numer Regon",
    labelKRSNumber: "Numer KRS",
    labelStreet: "Adres sklepu",
    labelZipCode: "Kod pocztowy",
    labelCity: "Miasto",
    labelUrl: "Link URL do zdjęcia",
    labelShopCategory: "Kategoria sklepu",
    btnRegisterShop: "Zarejestruj Sklep",
  };
}
