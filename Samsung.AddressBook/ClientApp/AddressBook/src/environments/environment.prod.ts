const baseUri = 'https://localhost:7118/api/v1';
const contactsUri = `${baseUri}/contacts`
const addressesUri = `${baseUri}/addresses`
const phonesUri = `${baseUri}/phones`

export const environment = {
  contactsUri,
  addressesUri,
  phonesUri,
  production: true
};
