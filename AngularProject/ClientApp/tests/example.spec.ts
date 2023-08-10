import { test, expect } from '@playwright/test';

test('easy-peasy', async ({ page }) => {
  await page.goto('/get-people');

  let tableLabel = await page.getByTestId('x').textContent();

  await expect(tableLabel).toEqual('People contacts');
});

test('add new person', async ({ page }) => {
  await page.goto('/get-people');

  await page.locator('tr').first().waitFor();
  let countBeforeAdding = await page.locator('tr').count();

  // Click the add new person button and fill inputs.
  await page.getByRole('button', { name: 'Add New Person' }).click();

  await page.getByTestId('FirstName').fill('test');
  await page.getByTestId('Surname').fill('test');
  await page.getByTestId('DateOfBirth').fill('2023-09-07');
  await page.getByTestId('Address').fill('test');
  await page.getByTestId('Phone').fill('test');
  await page.getByTestId('IBAN').fill('test');

  await page.getByRole('button', { name: 'Add', exact: true }).click();
  await page.locator(`.btn-close`).click();
  await page.waitForTimeout(3000);

  let countAfterAdding = await page.locator('tr').count();

  // Expects the rows to be +1.
  await expect(countBeforeAdding + 1).toEqual(countAfterAdding);
});
