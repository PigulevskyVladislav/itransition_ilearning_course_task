package by.itransition.ilearning.third_task;

import org.bouncycastle.util.encoders.Hex;

import java.util.Scanner;

public class Dialog {
    private String[] args;
    private int choice;
    private int bot_choice;

    public void BeginDialog(String[] args) {
        this.args = args;
        if(args.length < 3 || args.length % 2 == 0 || CheckDuplicates()) {
            System.out.print("The number of arguments must be odd and more than 3.");
            return;
        }
        ComputerPlayer bot = new ComputerPlayer(args);
        System.out.println("HMAC:\n" + Hex.toHexString(bot.GenerateHMAC()));
        ConfirmChoice("Your", choice = MakeChoice());
        ConfirmChoice("Computer", bot_choice = bot.getChoice());
        GetResult();
        System.out.println("HMAC key: " + bot.getKey());
    }

    private boolean CheckDuplicates() {
        int lng = args.length;
        for (int i = 0; i < lng; i++) {
            for (int j = i + 1; j < lng; j++) {
                if (args[i].equals(args[j])) {
                    return true;
                }
            }
        }
        return false;
    }

    private int MakeChoice() {
        Scanner scn = new Scanner(System.in);
        boolean correct = false;
        int choice = 0;
        while (!correct) {
            try {
                OfferChoice();
                choice = scn.nextInt();
                if (choice >= 0 && choice <= args.length) correct = true;
            } catch (Exception ignored) { }
        }
        if (choice == 0) System.exit(0);
        return choice - 1;
    }

    private void OfferChoice() {
        System.out.println("Available moves:");
        for (int i = 0; i < args.length; i++) {
            System.out.println((i + 1) + " - " + args[i]);
        }
        System.out.println("0 - exit");
        System.out.print("Enter your move: ");
    }

    private void ConfirmChoice(String name, int choice) {
        System.out.println(name + " move: " + args[choice]);
    }

    private void GetResult() {
        if (choice == bot_choice) {
            System.out.println("Draw!");
            return;
        }
        int lng = args.length;
        int half = lng / 2;
        int index;
        for (int i = 1; i <= half; i++) {
            index = choice + i < lng ? choice + i : choice + i - lng;
            if (index == bot_choice) {
                ConfirmLose();
                return;
            }
        }
        ConfirmWin();
    }

    private void ConfirmWin() {
        System.out.println("You win!");
    }

    private void ConfirmLose() {
        System.out.println("You lose!");
    }
}
