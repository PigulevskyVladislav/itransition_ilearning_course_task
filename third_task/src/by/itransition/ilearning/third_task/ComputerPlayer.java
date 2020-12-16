package by.itransition.ilearning.third_task;

import org.bouncycastle.jcajce.provider.digest.SHA3;

import java.math.BigInteger;
import java.security.SecureRandom;
import java.util.Random;

public class ComputerPlayer {

    private String[] args;
    private int choice;
    private String key;

    public ComputerPlayer(String[] args) {
        this.args = args;
        MakeMove();
        GenerateKey();
    }

    public int getChoice() {
        return choice;
    }

    public String getKey() {
        return key;
    }

    public byte[] GenerateHMAC() {
        String input = args[choice].concat(key);
        return new SHA3.Digest256().digest(input.getBytes());
    }

    private void MakeMove() {
        choice = new Random().nextInt(args.length);
    }

    private void GenerateKey() {
        SecureRandom secureRandom = new SecureRandom();
        byte[] token = new byte[16];
        secureRandom.nextBytes(token);
        key = new BigInteger(1, token).toString(16);
    }
}
